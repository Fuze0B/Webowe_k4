using System;
using System.Text.Json;

namespace Perfumy.Models;

public class FilePerfumesRepo : IPerfumesRepo
{
    private readonly string filePath = "perfumes.json";
    private List<Perfume> _perfumes;
    private void LoadPerfumesFromFile()

    {
        if(!File.Exists(filePath))
        {
            _perfumes = new List<Perfume>();
            return;
        }
        var result = File.ReadAllText(filePath);
        _perfumes = JsonSerializer.Deserialize<List<Perfume>>(result)
            ?? new List<Perfume>();
    }
    public FilePerfumesRepo()
    {
        LoadPerfumesFromFile();
        Perfumes = _perfumes;
    }
    public List<Perfume> Perfumes { get; set; }


    public void AddPerfume(Perfume perfume)
    {
        perfume.Id = GetNextId();
        Perfumes.Add(perfume);
        var json = JsonSerializer.Serialize(Perfumes);
        File.WriteAllText(filePath, json);
    }

    private void SaveToFile()
    {
        var json = JsonSerializer.Serialize(Perfumes);
        File.WriteAllText(filePath, json);
    }
    public Perfume? GetPerfume(int id)
    {
        return Perfumes.FirstOrDefault(c => c.Id == id);
    }

    public void RemovePerfume(int id)
    {
        Perfume? perfumeToRemove = Perfumes.FirstOrDefault(c => c.Id == id);
        if (perfumeToRemove != null)
        {
            Perfumes.Remove(perfumeToRemove);
            SaveToFile();
        }
    }

     private int GetNextId()
    {
        if (Perfumes.Count == 0) return 1;
        return Perfumes.Max(c => c.Id) + 1;
    }

    public void UpdatePerfume(Perfume perfume)
    {
                var perfumeToUpdate = GetPerfume(perfume.Id);
        if(perfumeToUpdate != null)
        {
            perfumeToUpdate.Brand = perfume.Brand;
            perfumeToUpdate.Model = perfume.Model;
            perfumeToUpdate.Scent = perfume.Scent;
            perfumeToUpdate.Amount = perfume.Amount;
            SaveToFile();
        }
        
    }
}