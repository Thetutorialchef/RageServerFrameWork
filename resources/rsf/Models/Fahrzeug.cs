using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GTANetworkAPI;

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
        [NotMapped]
        public Vehicle Vehicle { get; set; }

        public Fahrzeug()
        {
            Fahrzeuge.Add(this);
        }
        public void Spawn()
        {
            
            Vehicle = NAPI.Vehicle.CreateVehicle(NAPI.Util.VehicleNameToModel(Name), new Vector3(PosX, PosY, PosZ), new Vector3(RotX, RotY, RotZ), PrimaryColor, SecondaryColor, NumberPlate, 255, Locked, Engine, Dimension);
        }
    }
}
