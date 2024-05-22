using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPINormal.DTO;

namespace DAL.Repositories
{
    public class ProductRateRepository : IRepository<ProductRateDTO> // Adapter pour manipuler des DTO
    {
        private readonly PrintContext _context;

        public ProductRateRepository(PrintContext context)
        {
            _context = context;
        }

        public void Add(ProductRateDTO entity)
        {
            // Créez une nouvelle entité ProductRate à partir du DTO
            var newProductRate = new ProductRate
            {
                ProductCode = entity.ProductCode,
                ProductName = entity.ProductName,
                Price = entity.Price,
                IsActive = entity.IsActive
                // Mappez les autres propriétés ici
            };

            // Ajoutez la nouvelle entité à la base de données
            _context.ProductRates.Add(newProductRate);
            _context.SaveChanges();
        }

        public ProductRateDTO GetById(int id)
        {
            // Recherchez le ProductRate par son ID
            var productRate = _context.ProductRates.Find(id);


            if (productRate == null)
            {
                return null;
            }

            // Créez un DTO à partir de l'entité trouvée
            var productRateDTO = new ProductRateDTO(
                productRate.IdProduct,
                productRate.ProductCode,
                productRate.ProductName,
                productRate.Price,
                productRate.IsActive
            // Ajoutez les autres propriétés si nécessaire
            );

            return productRateDTO;
        }

        public IEnumerable<ProductRateDTO> GetAll()
        {
            // Récupérez tous les ProductRates de la base de données et les mappez vers des DTO
            return _context.ProductRates.Select(productRate => new ProductRateDTO(
                productRate.IdProduct,
                productRate.ProductCode,
                productRate.ProductName,
                productRate.Price,
                productRate.IsActive
            // Ajoutez les autres propriétés si nécessaire
            )).ToList();
        }

        public ProductRateDTO GetByProductCode(string productCode)
        {
            // Recherchez le ProductRate par son code de produit
            var productRate = _context.ProductRates.FirstOrDefault(p => p.ProductCode == productCode);

            // Vérifiez si le produit a été trouvé
            if (productRate != null)
            {
                // Créez un DTO à partir de l'entité trouvée
                var productRateDTO = new ProductRateDTO(
                    productRate.IdProduct,
                    productRate.ProductCode,
                    productRate.ProductName,
                    productRate.Price,
                    productRate.IsActive
                // Ajoutez les autres propriétés si nécessaire
                );

                return productRateDTO;
            }
            
                return null;
            
        } 

        public bool IsProductActive(int id)
        {
            var productRate = _context.ProductRates.Find(id);
            if (productRate != null)
            {
                return productRate.IsActive;
            }
            return false;
        }



        public void Remove(int id)
        {
            // Recherchez le ProductRate par son ID
            var productRate = _context.ProductRates.Find(id);
            if (productRate != null)
            {
                // Supprimez le ProductRate de la base de données
                _context.ProductRates.Remove(productRate);
                _context.SaveChanges();
            }
        }

        public void Update(ProductRateDTO entity)
        {
            // Recherchez le ProductRate par son ID
            var productRate = _context.ProductRates.Find(entity.IdProduct);
            if (productRate != null)
            {
                // Mettez à jour les propriétés du ProductRate avec celles du DTO
                productRate.ProductCode = entity.ProductCode;
                productRate.ProductName = entity.ProductName;
                productRate.Price = entity.Price;
                productRate.IsActive = entity.IsActive;

                // Mettez à jour l'entité dans la base de données
                _context.SaveChanges();
            }
        }
    }
}

