using SportTestAPI.DataModels;
using SportTestAPI.Dto;

namespace SportTestAPI.IGenericRepo
{
    public interface IPaymentRepository
    {
        Payment CreatePayment(PaymentDto payementDto);
        Payment ExecutePayment(string paymentId, string payerId);
    }
}
