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
                List<Contact> allContacts = Contact.GetAll();
                return View["contacts.cshtml", allContacts];
            };
            Get["/contacts/new"] = _ => {
                return View["contact_form.cshtml"];
            };
            Post["/contact/new"] = _ => {
                string contactName = Request.Form["contact-name"];
                string contactPhone = Request.Form["contact-phone"];
                Contact newContact = new Contact(contactName, contactPhone);
                return View["contact_made.cshtml", newContact];
            };
            Post["/contacts/new_address_or_not/{id}"] = parameters => {
                string addressOrNot = Request.Form["address-or-not"];
                if(addressOrNot == "return")
                {
                    List<Contact> allContacts = Contact.GetAll();
                    return View["contacts.cshtml", allContacts];
                }
                else
                {
                    Contact selectedContact = Contact.Find(parameters.id);
                    return View["contact_address_form.cshtml", selectedContact];
                }
            };
            Post["/contact/new_address/{id}"] = parameters => {
                string contactStreet = Request.Form["contact-street"];
                string contactApt = Request.Form["contact-apt"];
                string contactCity = Request.Form["contact-city"];
                string contactState = Request.Form["contact-state"];
                string contactZip = Request.Form["contact-zip"];
                Address newAddress = new Address(contactStreet, contactCity, contactState, contactZip);
                newAddress.AddStreet(contactApt);
                Contact selectedContact = Contact.Find(parameters.id);
                selectedContact(parameters.id).SetAddress(newAddress);
                return View["address-added.cshtml", selectedContact];
            };
        }
    }
}
