using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Kutlariz.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kutlariz.Business.Services.PaymentService.Iyzico
{
    public class IyzicoPaymentManager : IPaymentService
    {
        public Payment Pay(OrderDto dto)
        {
            Options options = new Options
            {
                ApiKey = IyzicoKeys.API_KEY,
                SecretKey = IyzicoKeys.SECRET_KEY,
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };

            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = dto.Price.ToString().Replace(",", "."),
                PaidPrice = dto.Price.ToString().Replace(",", "."),
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString()
            };

            PaymentCard paymentCard = new PaymentCard
            {
                CardHolderName = dto.CardHolderName,
                CardNumber = dto.CardNumber,
                ExpireMonth = dto.ExpireMonth,
                ExpireYear = "20" + dto.ExpireYear,
                Cvc = dto.Cvc
            };
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer
            {
                Id = dto.UserId,
                Name = dto.BirthdayPersonName.Split(" ")[0],
                Surname = dto.BirthdayPersonName.Split(" ").Last(),
                GsmNumber = dto.PhoneNumber,
                Email = dto.Email,
                IdentityNumber = "74300864791",
                RegistrationAddress = dto.AddressDescription,
                Ip = "85.34.78.112",
                City = "İzmir",
                Country = "Turkey"
            };
            request.Buyer = buyer;

            Address shippingAddress = new Address
            {
                ContactName = dto.BirthdayPersonName,
                City = "İzmir",
                Country = "Turkey",
                Description = dto.AddressDescription
            };
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address
            {
                ContactName = dto.BirthdayPersonName,
                City = "İzmir",
                Country = "Turkey",
                Description = dto.AddressDescription
            };
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();

            BasketItem basketItem = new BasketItem
            {
                Id = Guid.NewGuid().ToString(),
                Name = dto.CakeType.ToString() + "Pasta",
                Category1 = "Doğum günü pastası",
                ItemType = BasketItemType.PHYSICAL.ToString(),
                Price = Math.Round(dto.Price, 3, MidpointRounding.AwayFromZero).ToString().Replace(",", ".")
            };
            basketItems.Add(basketItem);
            request.BasketItems = basketItems;

            Payment payment = Payment.Create(request, options);

            return payment;
        }
    }
}
