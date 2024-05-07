using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTelefone
{
    internal class Address
    {
        string ZipCode;
        string City;
        string State;
        string TypePatio;
        string StreetAvenue;
        string Neighborhood;
        int Number;
        string Complement;

        public Address(string zipCode, string city, string state, string typePatio, string streetAvenue, string neighborhood, int number, string complement)
        {
            ZipCode = zipCode;
            City = city;
            State = state;
            TypePatio = typePatio;
            StreetAvenue = streetAvenue;
            Neighborhood = neighborhood;
            Number = number;
            Complement = complement;
        }

        public override string? ToString()
        {
            string valor = $"\nEndereco:\nCEP:{ZipCode};\nLocalidade: {City},{State};\nLogradouro:{TypePatio} {StreetAvenue}, nº {Number};\nBairro: {Neighborhood};";
            if (this.Complement != "")
                valor += $"\nComplemento: {Complement};";
            return valor;
        }
    }
}
