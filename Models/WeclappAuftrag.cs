using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKarteAPI.Models
{
    //Définition d'une classe WeclappResult, qui peut etre utilisé avec un type de donnée random(T)
    public class WeclappResult<T>
    {
        //La propriété result(un tableau de type random(T)) a des accesseurs get et set permettant de la lire et l'écrire à l'extérieur de la classe
        public T[] result { get; set; }
    }

    //La classe WeclappAuftragen hérite des propriétés et méthodes de la classe WeclappResult, qui utilise des données de type WeclappAuftrag
    public class WeclappAuftragen : WeclappResult<WeclappAuftrag> { }

    //La classe WeclappAddresses hérite des propriétés et méthodes de la classe WeclappResult, qui utilise des données de type WeclappAddress
    public class WeclappAddresses : WeclappResult<WeclappAddress> { }

    //Définition de la classe WeclappAddress avec des propriétés
    public class WeclappAddress
    {
        // Attributs avec accesseurs get et set
        public string company { get; set; }
        public string company2 { get; set; }
        public string city { get; set; }
        public string street1 { get; set; }
        public string zipcode { get; set; }
        // Constructeur
        public WeclappAddress() { }
    }

    //Définition de la classe WeclappAuftrag
    public class WeclappAuftrag
    {
        // Attributs avec accesseurs get et set
        public string customerNumber { get; set; }
        public string netAmount { get; set; }
        public string createdDate { get; set; }

        // Attribut deliveryAddress(de type WeclappAddress) avec accesseurs get et set
        public WeclappAddress deliveryAddress { get; set; }

        // Constructeur
        public WeclappAuftrag() { }
    }
}
