using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GTANetworkAPI;
using Remotion.Linq.Parsing.ExpressionVisitors.Transformation.PredefinedTransformations;

namespace Server.resources.rsf.Models
{
    public class Fahrzeug : Script
    {
        public static List<Fahrzeug> Fahrzeuge = new List<Fahrzeug>();
        public string Name { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public float RotX { get; set; }
        public float RotY { get; set; }
        public float RotZ { get; set; }
        public int PrimaryColor { get; set; }
        public int SecondaryColor { get; set; }
        public string NumberPlate { get; set; } = "";
        public uint Dimension { get; set; }
        public bool Locked { get; set; }
        public bool Engine { get; set; }
        public bool BlinkerL { get; set; }
        public bool BlinkerR { get; set; }
        public Dictionary<int, bool> Extra = new Dictionary<int, bool>();
        public int Livery { get; set; }
        [NotMapped]
        public Vehicle Vehicle { get; set; }

        public Fahrzeug()
        {
            Fahrzeuge.Add(this);
        }
        public void Spawn()
        {
            NAPI.Util.ConsoleOutput($"{Dimension}");
            Vehicle = NAPI.Vehicle.CreateVehicle(NAPI.Util.GetHashKey(Name), new Vector3(PosX, PosY, PosZ), RotZ, PrimaryColor, SecondaryColor, NumberPlate, 255, Locked, Engine, Dimension);
            Vehicle.SetData("Fahrzeug", this);
            Vehicle.SetSharedData("BlinkerL", BlinkerL);
            Vehicle.SetSharedData("BlinkerR", BlinkerR);
            for(var i = 0; i < 30; i++)
            {
                Extra.Add(i, Vehicle.GetExtra(i));
                Vehicle.SetExtra(i, true);
                Vehicle.SetExtra(i, Extra[i]);
            }

            SetLivery(Livery);
            Vehicle.SetSharedData("Extra", Extra);
        }

        public void AddExtra(int id, bool state)
        {
            Vehicle.SetExtra(id, true);
            Extra[id] = state;
            Vehicle.SetExtra(id, Extra[id]);
        }

        public void SetLivery(int livery)
        {
            Livery = livery;
            Vehicle.Livery = livery;
        }
    }
}
