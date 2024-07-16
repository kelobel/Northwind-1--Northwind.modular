using Northwind.Regions.Application.Base;
using Northwind.Regions.Application.Dtos;

namespace Northwind.Regions.Application.Extensions
{
    public static class ValidateRegion
    {
        public static ServiceResult IsValidRegion(this RegionDtoBase baseRegion)
        {
            ServiceResult result = new ServiceResult();

            if (baseRegion is null)
            {
                result.Success = false;
                result.Message = $"El objeto {nameof(baseRegion)} es requerido.";
                return result;
            }


            
            result.Success = true;
            result.Message = "La región es válida.";
            return result;
        }
    }
}
