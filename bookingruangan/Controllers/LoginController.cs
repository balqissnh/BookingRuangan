using System.Windows.Forms;
using bookingruangan.Models;
using bookingruangan.Services;


namespace bookingruangan.Controllers
{
    public class LoginController
    {
        private login _view;

        public LoginController(login view)
        {
            _view = view;
        }

        public string HandleLogin(string username, string password)
        {
            return LoginService.CekLogin(username, password);
        }
    }
}
