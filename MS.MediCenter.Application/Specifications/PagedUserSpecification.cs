using Ardalis.Specification;
using MS.MediCenter.Core.Security;

namespace MS.MediCenter.Application.Specifications
{
    public class PagedUserSpecification : Specification<User>
    {
        public PagedUserSpecification(int pageSize, int pageNumber, string nombre)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (string.IsNullOrEmpty(nombre))
            {
                Query.Search(x => x.Nombre, "%" + nombre + "%");
            }
        }
    }
}
