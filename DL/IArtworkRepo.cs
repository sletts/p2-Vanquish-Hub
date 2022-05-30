using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DL
{
    public interface IArtworkRepo
    {
        Artwork AddArt(Artwork art);
        List<Artwork> GetAllArtworks();
        List<Artwork> GetArtByUserID(int UserId);
        void DeleteArt(int id);
    }
}
