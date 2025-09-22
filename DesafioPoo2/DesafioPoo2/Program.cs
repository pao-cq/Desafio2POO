using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesafioPoo2.Vehiculo;

namespace DesafioPoo2
{
    //Clase Base vehiculo con sus atributos
    public class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public int Velocidad { get; set; }
        public Vehiculo(string marca, string modelo, int año)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Año = año;
            this.Velocidad = 0;
        }
        public virtual void Encender()
        {
            Console.WriteLine($"{this.Marca} {this.Modelo} encendido");
        }
        public virtual void Acelerar()
        {
            this.Velocidad += 10;
            Console.WriteLine($"{this.Marca} {this.Modelo} acelerando a {this.Velocidad} km/h");
        }
        public virtual void Detener()
        {
            this.Velocidad = 0;
            Console.WriteLine($"{this.Marca} {this.Modelo} detenido");
        }
        public virtual void Reporte()
        {
            Console.WriteLine($"Marca: {this.Marca}, Modelo: {this.Modelo}, Año: {this.Año}, Velocidad: {this.Velocidad} km/h");
        }


        //Subclases: AutoElectrico, AutoGasolina y AutoAutonomo
        public class AutoAutonomo : Vehiculo
        {
            public AutoAutonomo(string marca, string modelo, int año) : base(marca, modelo, año) { }
            public override void Encender()
            {
                Console.WriteLine($"{this.Marca} {this.Modelo} (autónomo) encendido y en modo autónomo");
            }

            public override void Reporte()
            {
                Console.WriteLine($"Autonomo: {this.Marca}, {this.Modelo} ({this.Año}) - Velocidad: {this.Velocidad} km/h");
            }
        }
        public class AutoElectrico : Vehiculo
        {
            public AutoElectrico(string marca, string modelo, int año) : base(marca, modelo, año) { }
            public override void Encender()
            {
                Console.WriteLine($"{this.Marca} {this.Modelo} (eléctrico) encendido y batería recargada");
            }
            public override void Reporte()
            {
                Console.WriteLine($"Eléctrico: {this.Marca}, {this.Modelo} ({this.Año}) - Velocidad: {this.Velocidad} km/h");
            }
        }
        public class AutoGasolina : Vehiculo
        {
            public AutoGasolina(string marca, string modelo, int año) : base(marca, modelo, año) { }
            public override void Encender()
            {
                Console.WriteLine($"{this.Marca} {this.Modelo} (gasolina) encendido y gasolina llena");
            }
            public override void Reporte()
            {
                Console.WriteLine($"Gasolina: {this.Marca}, {this.Modelo} ({this.Año}) - Velocidad: {this.Velocidad} km/h");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Arreglo de vehículos
            Vehiculo[] flota = new Vehiculo[3];
            flota[0] = new AutoElectrico("Tesla", "Model S", 2022);
            flota[1] = new AutoGasolina("Kia", "SUV's", 2021);
            flota[2] = new AutoAutonomo("Nissan", "One", 2024);


            //Iterar sobre cada vehículo en la flota
            foreach (var vehiculo in flota)
            {
                vehiculo.Encender();
                vehiculo.Acelerar();
                vehiculo.Detener();
                vehiculo.Reporte();
                Console.WriteLine();
            }
            Console.WriteLine("Presione Enter para salir");
            Console.ReadKey();
        }
    }
}
