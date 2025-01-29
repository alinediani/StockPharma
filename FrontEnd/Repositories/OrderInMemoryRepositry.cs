using FrontEnd.Models;

namespace FrontEnd.Repositories
{
    public class OrderInMemoryRepositry
    {
        private readonly List<Order> _orders = new List<Order>();
        public void Add(Order order)
        {
            order.Id = _orders.Any() ? _orders.Max(o => o.Id) + 1 : 1;
            _orders.Add(order);
        }

        public List<Order> GetAll()
        {
            return _orders.ToList();
        }

        public Order GetById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public bool Update(Order order)
        {
            var existingOrder = GetById(order.Id);
            if (existingOrder == null)
            {
                return false;
            }

            existingOrder.Client = order.Client;
            existingOrder.Products = order.Products;
            existingOrder.CreatedDate = order.CreatedDate;
            existingOrder.TotalValue = order.TotalValue;

            return true;
        }

        public bool Delete(int id)
        {
            var order = GetById(id);
            if (order == null)
            {
                return false;
            }

            _orders.Remove(order);
            return true;
        }

        public void Save()
        {
           
        }
    }

}
