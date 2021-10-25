create table Empresas.TipoDocumento
(
	IdTipoDocumento	numeric(5,0) Identity(1,1),
	Descripcion varchar(60),
	constraint pk_tipo_documento primary key(IdTipoDocumento)
)
go
create table Empresas.Empresa
(
	IdEmpresa		numeric(5,0) Identity(1,1),
	IdTipoDocumento numeric(5,0)	not null,
	Documento		varchar(15)		not null,
	RazonSocial		varchar(250)	not null,
	Estado			bit				not null,
	Direccion		varchar(250)	not null,
	UsuarioReg		int				not null,
	FechaReg		datetime		not null,
	UsuarioModi		numeric(8,0)	null,
	FechaModi		datetime		null,

	constraint pk_empresa primary key(IdEmpresa),
	--constraint fk_empresa_usuario_reg foreign key (UsuarioReg) references Seguridad.Usuario(IdUsuario),
	--constraint fk_empresa_usuario_mod foreign key (UsuarioReg) references Seguridad.Usuario(IdUsuario),
	constraint fk_empresa_tipo_documento foreign key (IdTipoDocumento) references Empresas.TipoDocumento(IdTipoDocumento)
)
create table Empresas.Empleado
(
	IdEmpleado		numeric(12,0) identity(1,1),
	IdEmpresa		numeric(5,0),
	IdTipoDocumento numeric(5,0),
	Documento		varchar(15),
	Nombres			varchar(250),
	ApellidoPaterno varchar(150),
	ApellidoMaterno varchar(150),
	FechaNacimiento datetime,

	constraint pk_empleado primary key(IdEmpleado),
	constraint fk_empleado_empresa foreign key (IdEmpresa) references Empresas.Empresa(IdEmpresa),
	constraint fk_empleado_tipo_documento foreign key (IdTipoDocumento) references Empresas.TipoDocumento(IdTipoDocumento)
)
go
go
create table Seguridad.Usuario(
	IdUsuario	numeric(8,0) identity(1,1),
	IdEmpleado	numeric(12,0),
	Nombre		varchar(50),
	IdRol		int,
	Estado		char(1),
	FechaVencimientoContrasenia datetime,
	Contrasenia varchar(450) ,
	constraint pk_usuario primary key(IdUsuario),
	constraint fk_usuario_empleado foreign key (IdEmpleado) references Empresas.Empleado(IdEmpleado)
)
go
create table Empresas.Sucursal
(
	IdSucursal	numeric(5,0) Identity(1,1),
	IdEmpresa	numeric(5,0),
	Codigo		varchar(10),
	Nombre		varchar(150),
	Direccion	varchar(250)

	constraint pk_sucursal primary key(IdSucursal),
	constraint fk_empleado_empresa foreign key (IdEmpresa) references Empresas.Empresa(IdEmpresa)
)
go
create schema Almacen;
go
create table Almacen.Fabricante
(
	IdFabricante numeric(5,0) Identity(1,1),
	IdEmpresa	 numeric(5,0),
	Nombre		 varchar(250),
	constraint pk_fabricante primary key(IdFabricante),
	constraint fk_fabricante_empresa foreign key (IdEmpresa) references Empresas.Empresa(IdEmpresa)
)
go
create table Almacen.Categoria
(
	IdCategoria numeric(5,0) Identity(1,1),
	IdEmpresa	numeric(5,0),
	Nombre		varchar(250),
	constraint pk_categoria primary key(IdCategoria),
	constraint fk_categoria_empresa foreign key (IdEmpresa) references Empresas.Empresa(IdEmpresa)
)
go
create table Almacen.Presentacion
(
	IdPresentacion	numeric(5,0) Identity(1,1),
	IdEmpresa		numeric(5,0),
	Nombre			varchar(250),
	constraint pk_presentacion primary key(IdPresentacion),
	constraint fk_presentacion_empresa foreign key (IdEmpresa) references Empresas.Empresa(IdEmpresa)
)
go
create table Almacen.Lote
(
	IdLote		numeric(7,0) identity(1,1),
	IdEmpresa	numeric(5),
	Codigo		varchar(12),
	Descripcion varchar(250),
	Fecha		datetime,
	constraint pk_lote primary key (IdLote),
	constraint fk_lote_empresa	foreign key (IdEmpresa)	references Empresas.Empresa(IdEmpresa),
	constraint uq_lote	unique (IdEmpresa, Codigo)

)
go
go
create table Almacen.AfectacionIgv
(
	IdAfectacionIgv numeric(5,0) identity(1,1),
	Codigo			varchar(5),
	Descripcion		varchar(50),
	constraint pk_afectacionigv primary key (IdAfectacionIgv),
)
go
create table Almacen.Producto
(
	IdProducto		numeric(18,0) identity(1,1),
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
	IdAfectacionIgv numeric(5,0),
	constraint pk_producto primary key (IdProducto),
	constraint fk_producto_empresa		foreign key (IdEmpresa)		references Empresas.Empresa(IdEmpresa),
	constraint fk_producto_presentacion foreign key (IdPresentacion) references Almacen.Presentacion(IdPresentacion),
	constraint fk_producto_categoria	foreign key (IdCategoria)	references Almacen.Categoria(IdCategoria),
	constraint fk_producto_afectacionIgv foreign key (IdAfectacionIgv)	references Almacen.AfectacionIgv(IdAfectacionIgv)
)
go
create table Almacen.MedicamentoFabricante
(
	IdMedicamento numeric(18,0),
	IdFabricante  numeric(5,0),
	IdEmpresa	  numeric(5,0),
	constraint fk_medicamentofabricante_producto   foreign key (IdMedicamento) references Almacen.Producto(IdProducto),
	constraint fk_medicamentofabricante_fabricante foreign key (IdFabricante)  references Almacen.Fabricante(IdFabricante),
	constraint fk_medicamentofabricante_empresa	   foreign key (IdEmpresa)	   references Empresas.Empresa(IdEmpresa)
)
go
create schema Ventas
go
create table Ventas.Cliente
(
	IdCliente		numeric(12,0) identity(1,1),
	IdEmpresa		numeric(5,0),
	IdTipoDocumento numeric(5,0),
	Documento		varchar(15),
	Nombre			varchar(250),
	ApellidoPaterno varchar(150),
	ApellidoMaterno varchar(150),
	FechaNacimiento datetime

	constraint pk_cliente primary key (IdCliente),
	constraint fk_cliente_empresa foreign key (IdEmpresa) references Empresas.Empresa(IdEmpresa),
	constraint fk_cliente_tipo_documento foreign key (IdTipoDocumento) references Empresas.TipoDocumento(IdTipoDocumento)
)
go
create table Ventas.TipoComprobante
(
	IdTipoComprobante numeric(5,0) identity(1,1),
	Descripcion		  varchar(80),
	constraint pk_tipo_comprobante primary key(IdTipoComprobante)
)
go
create table Empresas.Moneda
(
	IdMoneda	numeric(5,0) identity(1,1),
	IdEmpresa	numeric(5,0),
	Simbolo		varchar(10),
	Codigo		varchar(10),
	Descripcion varchar(150),
	Estado		bit,
	Venta		numeric(8,4),
	Compra		numeric(8,4),
	FechaAxtualizacion datetime
)
go
create table Empresas.TipoCambio
(
	IdEmpresa numeric(5,0),
	Fecha	  date,
	Venta	  numeric(8,4),
	Compra	  numeric(8,4)
)
go
create table Ventas.Comprobante
(
	IdComprobante	numeric(18,0) identity(1,1),
	IdEmpresa		numeric(5,0),
	IdSucursal		numeric(5,0),
	IdCliente		numeric(12,0),
	Serie			varchar(6),
	Correlativo		numeric(12,0),
	FechaEmision	datetime,
	Estado			bit,
	IdMoneda		numeric(5,0),
	TipoCambio		numeric(8,4),
	FechaAnulacion	datetime,
	Importe			numeric(18,2),
	FactorDescuento	numeric(5,2),
	Descuento		numeric(18,2),
	Subtotal		numeric(18,2),
	FactorIgv		numeric(18,2),
	Igv				numeric(6,2),
	Total			numeric(18,2),
	constraint pk_comprobante		   primary key(IdComprobante),
	constraint fk_comprobante_empresa  foreign key(IdEmpresa) references Empresas.Empresa(IdEmpresa),
	constraint fk_comprobante_sucursal foreign key(IdSucursal) references Empresas.Sucursal(IdSucursal),
	constraint fk_comprobante_cliente  foreign key(IdCliente) references Ventas.Cliente(IdCliente)
)
go
create table Ventas.DetalleComprobante
(
	IdDetalleComprobante numeric(18,0) identity(1,1),
	IdComprobante		 numeric(18,0),
	IdProducto			 numeric(18,0),
	IdAfectacionIGV		 numeric(5,0),
	Cantidad			 numeric(12,4),
	ValorUnitario		 numeric(12,2),
	FactorDescuento		 numeric(5,2),
	Descuento			 numeric(12,2),
	Importe				 numeric(12,2),

	constraint pk_detallecomprobante primary key(IdDetalleComprobante),
	constraint fk_detallecomprobante_comprobante  foreign key(IdComprobante) references Ventas.Comprobante(IdComprobante),
	constraint fk_detallecomprobante_producto foreign key(IdProducto) references Almacen.Producto(IdProducto),
	constraint fk_detallecomprobante_afactacionigv foreign key(IdAfectacionIGV) references Almacen.AfectacionIgv(IdAfectacionIGV)
)
