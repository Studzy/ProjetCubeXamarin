using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class CommentairesModel
    {
        public int RessourceId { get; set; }
        public List<CommentaireData> Commentaires { get; set; }
    }
}
