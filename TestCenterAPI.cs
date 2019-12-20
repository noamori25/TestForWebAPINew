using ProjectManagmentSystem.BLL;
using ProjectManagmentSystem.Facade;
using ProjectManagmentSystem.POCO;
using System.Linq;

namespace UnitTestProject1
{
    public class TestCenerAPI
    {
        public FlyingCenterSystem f;
        public AnonymousUserFacade AnonymousFacade;
        public LoggedInAdministratorFacade AdminFacade;
        public LoginToken<Administrator> AdminToken;
        public LoggedInCustomerFacade CustomerFacade;
        public LoginToken<Customer> CustomerToken;
        public LoggedInAirlineFacade AirlineFacade;
        public LoginToken<AirlineCompany> AirlineToken;

        public TestCenerAPI()
        {
            f = FlyingCenterSystem.GetInstance();
            AnonymousFacade = (AnonymousUserFacade)f.GetFacade(null);
            AdminToken = (LoginToken<Administrator>)f.Login(FlightCenterConfig.ADMIN_USER, FlightCenterConfig.ADMIN_PASSWORD);
            AdminFacade = (LoggedInAdministratorFacade)f.GetFacade(AdminToken);
            AirlineCompany airline = GetAirlineFotTest();
            AirlineToken = (LoginToken<AirlineCompany>)f.Login(airline.UserName, airline.Password);
            AirlineFacade = (LoggedInAirlineFacade)f.GetFacade(AirlineToken);
            Customer c = GetCustomerForTest();
            CustomerToken =(LoginToken<Customer>)f.Login(c.UserName, c.Password);
            CustomerFacade = (LoggedInCustomerFacade)f.GetFacade(CustomerToken);
        }

        public Customer GetCustomerForTest()
        {
            Customer c = AdminFacade.GetAllCustomers(AdminToken).ToList()[0]; //new Customer
            return c;
        }
        
           public AirlineCompany GetAirlineFotTest ()
        {
            AirlineCompany a = AnonymousFacade.GetAllAirlineCompanies().ToList()[0];
            return a;
            
        }
        public Flight GetFlightFotTest ()
        {
            Flight f = AnonymousFacade.GetAllFlights().ToList()[0];
            return f;
        }
        public string GetToken (string userName, string password)
        {
            return $"{userName}:{password}";
        }
    }
}
