using Microsoft.Extensions.Logging;
using Northwind.Regions.Application.Base;
using Northwind.Regions.Application.Contracts;
using Northwind.Regions.Application.Dtos;
using Northwind.Regions.Application.Extensions;
using Northwind.Regions.Domain.Entities;
using Northwind.Regions.Domain.Interface;



namespace Northwind.Regions.Application.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository regionRepository;
        private readonly ILogger<RegionService> logger;

        public RegionService(IRegionRepository regionRepository, ILogger<RegionService> logger)
        {
            this.regionRepository = regionRepository;
            this.logger = logger;
        }

        public ServiceResult Add(RegionDtoSave regionDtoSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                // Validate DTO
                result = regionDtoSave.IsValidRegion();

                if (!result.Success)
                    return result;

                // Map DTO to entity
                var region = new Region()
                {
                    Id = regionDtoSave.RegionID,
                    RegionDescription = regionDtoSave.RegionDescription,
                };

                // Call repository method to save entity
                this.regionRepository.Save(region);
                result.Success = true;
                result.Message = "Regionsuccessfully added.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando la región.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                // Retrieve all regions using repository
                var regions = this.regionRepository.GetAll();

                // Map entities to DTOs
                result.Result = regions.Select(region => new RegionDtoGetAll()
                {
                    RegionID = region.Id,
                    RegionDescription = region.RegionDescription,
                }).ToList();

                result.Success = true;
                result.Message = "Region successfully obtained.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                // Retrieve region by ID using repository
                var region = this.regionRepository.GetEntityBy(id);

                if (region == null)
                {
                    result.Success = false;
                    result.Message = $"No se encontró la región con ID: {id}.";
                }
                else
                {
                    // Map entity to DTO
                    result.Result = new RegionDtoGetAll()
                    {
                        RegionID = region.Id,
                        RegionDescription = region.RegionDescription,
                    };
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la región.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(RegionDtoRemove regionDtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (regionDtoRemove == null)
                {
                    result.Success = false;
                    result.Message = $"El objeto {nameof(regionDtoRemove)} es requerido.";
                    return result;
                }

                // Map DTO to entity
                var region = new Region()
                {
                    Id = regionDtoRemove.RegionID,
                };

                // Call repository method to remove entity
                this.regionRepository.Remove(region);
                result.Success = true;
                result.Message = "Regionsuccessfully removed.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error removiendo la región.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(RegionDtoUpdate regionDtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                // Validate DTO
                result = regionDtoUpdate.IsValidRegion();

                if (!result.Success)
                    return result;

                // Map DTO to entity
                var region = new Region()
                {
                    Id = regionDtoUpdate.RegionID,
                    RegionDescription = regionDtoUpdate.RegionDescription,
                };

                // Call repository method to update entity
                this.regionRepository.Update(region);
                result.Success = true;
                result.Message = "Region successfully updated.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando la región.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
