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
            Get["/contact/{id}"] = parameters => {
                Contact selectedContact = Contact.Find(parameters.id);
                return View["contact.cshtml", selectedContact];
            };
            Get["/contact/delete/{id}"] = parameters => {
                Contact.Delete(parameters.id);
                List<Contact> allContacts = Contact.GetAll();
                return View["contacts.cshtml", allContacts];
            };
            Get["/contacts/search_form"] = _ => {
                return View["search_form.cshtml"];
            };
            Post["/contact/new"] = _ => {
                string contactName = Request.Form["contact-name"];
                string contactPhone = Request.Form["contact-phone"];
                Contact newContact = new Contact(contactName, contactPhone);
                return View["contact_made.cshtml", newContact];
            };
            Post["/contacts/new_address_or_not/{id}"] = parameters => {
                string addressOrNot = Request.Form["address-or-not"];
                Contact selectedContact = Contact.Find(parameters.id);
                Address noAddress = new Address("No Address", "", "", "");
                selectedContact.SetAddress(noAddress);
                if(addressOrNot == "return")
                {
                    List<Contact> allContacts = Contact.GetAll();
                    return View["contacts.cshtml", allContacts];
                }
                else
                {
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
                selectedContact.SetAddress(newAddress);
                return View["address-added.cshtml", selectedContact];
            };
            Post["/contacts/clear"] = _ => {
                Contact.ClearAll();
                return View["contacts_clear.cshtml"];
            };
            Post["/contacts/search"] = _ => {
                string userQuery = Request.Form["user-query"];
                List<Contact> searchedContacts = Contact.Search(userQuery);
                return View["contacts_searched.cshtml", searchedContacts];
            };
        }
    }
}
