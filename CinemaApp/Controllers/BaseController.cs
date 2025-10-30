using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers;

[Authorize]
[AutoValidateAntiforgeryToken]  //С този атрибут се пазим от  (Cross-Site Request Forgery) атаки
                               //когато имаме put,post,delete завка от браузъра моя сървър генерира 
                               //forgery token който разделя на две части едната част става бисквитка
                               //дугата hidden поле в html koito изпраща за въвеждане на данни
                               //щом дойде до някой метод ако двете части ги няма атрибута блокира!
public abstract  class BaseController : Controller
{
   
}
