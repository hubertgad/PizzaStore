using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using PizzaStore.Domain.Exceptions;
using PizzaStore.Domain.Models.OrderAggregate;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Services.EmailServices
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public async Task SendAsync(Order order)
        {
            try
            {
                var message = new MimeMessage();
                message.To.Add(new MailboxAddress(order.User.Name, order.User.Email));
                message.From.Add(new MailboxAddress("Pizza Store", "no-reply@hubertgad.net"));
                message.Subject = $"Pizza Store: Order #{ order.Id } summary";

                string body = SetEmailBody(order);

                message.Body = new TextPart(TextFormat.Html)
                {
                    Text = body
                };

                using var emailClient = new SmtpClient();
                emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                await emailClient.SendAsync(message);
                emailClient.Disconnect(true);
            }
            catch (Exception e)
            {
                throw new CannotSendEmailException("Cannot send e-mail message.", e);
            }
        }

        private string SetEmailBody(Order order)
        {
            StringBuilder body = new StringBuilder();

            body.Append(@"<style>
                table {
                  font-family: arial, sans-serif;
                  border-collapse: collapse;
                  width: 100%;
                }
  
                td, th {
                  border: 1px solid #dddddd;
                  text-align: left;
                  padding: 8px;
                }
  
                tr:nth-child(even) {
                  background-color: #dddddd;
                }  
                </style>");

            body.Append($"<h1>Hello, { order.User.Name }! Your order has been placed.</h1>");
            body.Append("<h2>Your order summary:</h2>");
            body.Append(@"<p>
              <table>
                <tr>
    	            <th>Product</th>
    	            <th>Price</th>
                </tr>");

            foreach (var item in order.OrderItems.Where(q => q.ParentItem == null))
            {
                body.Append(@$"<tr>
        	            <td>{ item.Product.Name }</td>
    	                <td>{ item.Product.Price } PLN</td>
                    </tr>");
                foreach (var childItem in order.OrderItems.Where(q => q.ParentItem == item))
                {
                    body.Append(@$"<tr>
        	            <td>+ { childItem.Product.Name }</td>
    	                <td>{ childItem.Product.Price } PLN</td>
                    </tr>");
                }
            }
            body.Append("</table></p>");
            body.Append($"<h3>Total price: { order.TotalPrice } PLN</h3>");

            body.Append("<h2>Your remarks: </h2>");
            body.Append($"<h3>{ order.Remarks }</h3>");

            body.Append("<h2>Soon, your delicious food will not be prepared! Nobody will come and deliver to you no meal!</h2>");

            return body.ToString();
        }
    }
}