namespace Perfumy.Models ;
interface IPerfumesRepo
{
    public List<Perfume> Perfumes { get; set; }
    Perfume? GetPerfume(int id);
    void AddPerfume(Perfume perfume);
    void RemovePerfume(int id);
     void UpdatePerfume(Perfume perfume);
}