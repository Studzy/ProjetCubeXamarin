using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class CreationData
    {

        public List<CategorieData> Categories { get; set; }
        public List<TypeRessourceData> TypeRessources { get; set; }
        public List<TypeRelationData> TypeRelations { get; set; }
        public int RessourceId { get; set; }

    }
}
