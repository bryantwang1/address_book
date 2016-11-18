using Nancy;
using AddressBook.Objects;
using System.Collections.Generic;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["contacts.cshtml"];
      };
      Get["/contacts/new"] = _ => {
        return View["contact_form.cshtml"];
      };
      Get["/contacts/new_address"] = _ => {
        return View["contact_address_form.cshtml"];
      };
    }
  }
}
