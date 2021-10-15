create table Usuario
(
	Id		numeric(8,0) Identity(1,1) primary key,
)
go
create table TipoDocumento
(
	Id		numeric(5,0) Identity(1,1) primary key
)
go
create table Empresa
(
	Id				numeric(5,0) Identity(1,1),
	IdTipoDocumento numeric(5,0)	not null,
	Documento		varchar(15)		not null,
	RazonSocial		varchar(250)	not null,
	Estado			bit				not null,
	Direccion		varchar(250)	not null,
	UsuarioReg		numeric(8,0)	not null,
	FechaReg		datetime		not null,
	UsuarioModi		numeric(8,0)	null,
	FechaModi		datetime		null,

	constraint pk_empresa primary key(Id),
	constraint fk_empresa_usuario_reg foreign key (UsuarioReg) references Usuario(Id),
	constraint fk_empresa_usuario_mod foreign key (UsuarioReg) references Usuario(Id),
	constraint fk_empresa_tipo_documento foreign key (IdTipoDocumento) references TipoDocumento(Id)
)
go
create table Sucursal
(
	Id			numeric(5,0) Identity(1,1),
	IdEmpresa	numeric(5,0),
	Codigo		varchar(10),
	Nombre		varchar(150),
	Direccion	varchar(250)

	constraint pk_sucursal primary key(Id),
	constraint fk_empleado_empresa foreign key (IdEmpresa) references Empresa(Id)
)
go
create table Empleado
(
	Id				numeric(12,0) identity(1,1),
	IdEmpresa		numeric(5,0),
	IdTipoDocumento numeric(5,0),
	Documento		varchar(15),
	Nombres			varchar(250),
	ApellidoPaterno varchar(150),
	ApellidoMaterno varchar(150),
	FechaNacimiento datetime,

	constraint pk_empleado primary key(Id),
	constraint fk_empleado_empresa foreign key (IdEmpresa) references Empresa(Id),
	constraint fk_empleado_tipo_documento foreign key (IdTipoDocumento) references TipoDocumento(Id)
)
go
create table Fabricante
(
	Id		numeric(5,0) Identity(1,1),
	Nombre	varchar(250),
	constraint pk_fabricante primary key(Id)
)
go
create table Categoria
(
	Id numeric(5,0) Identity(1,1),
	Nombre varchar(250),
	constraint pk_categoria primary key(Id)
)
go
create table Presentacion
(
	Id numeric(5,0) Identity(1,1),
	Nombre varchar(250),
	constraint pk_presentacion primary key(Id)
)
go
create table Producto
(
	Id				numeric(18,0) identity ,
	IdEmpresa		numeric(5,0),
	Nombre			varchar(400),
	PrincipioActivo varchar(150),
	Composicion		varchar(250),
	PrecioVenta		decimal(18,2),
	PrecioCompra	decimal(18,2),
	FechaVencimiento datetime,
	Stock			decimal(18,4),
	IdCategoria		numeric(5,0),
	IdPresentacion	numeric(5,0),

	constraint pk_producto primary key (Id),
	constraint fk_producto_empresa		foreign key (IdEmpresa)		references Empresa(Id),
	constraint fk_producto_presentacion foreign key (IdPresentacion) references Presentacion(Id),
	constraint fk_producto_categoria	foreign key (IdCategoria)	references Categoria(Id)
)
go
create table MedicamentoFabricante
(
	IdMedicamento numeric(18,0),
	IdFabricante  numeric(5,0),

	constraint fk_medicamentofabricante_producto   foreign key (IdMedicamento) references Producto(Id),
	constraint fk_medicamentofabricante_fabricante foreign key (IdFabricante)  references Fabricante(Id)
)
go

create table Comprobante
(
	Id				numeric(18,0) identity,
	IdEmpresa		numeric(5,0),
	IdSucursal		numeric(5,0),
	Serie			varchar(6),
	Correlativo		numeric(12,0),
	FechaEmision	datetime,
	Estado			bit,
	FechaAnulacion	datetime,
	Importe			numeric(18,2),
	Igv				numeric(18,2),
	Subtotal		numeric(18,2),
	Descuento		numeric(18,2)
)
