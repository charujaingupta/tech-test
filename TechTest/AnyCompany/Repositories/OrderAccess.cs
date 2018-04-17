using System;
using System.Data.SqlClient;
using AnyCompany.Repositories;
namespace AnyCompany
{
    internal class OrderAccess : IDataAccess<Order>
    {
        //should be moved to config file
        private static string ConnectionString = @"Data Source=(local);Database=Orders;User Id=admin;Password=password;";

        //can further be refactored to use command query pattern
        public void Save(Order order)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Orders VALUES (@OrderId, @Amount, @VAT)", connection);

            command.Parameters.AddWithValue("@OrderId", order.OrderId);
            command.Parameters.AddWithValue("@Amount", order.Amount);
            command.Parameters.AddWithValue("@VAT", order.VAT);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public Order Load(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
