using System;
using System.Threading;

namespace AdministracionCuentasBancarias
{
    class Program
    {
        static void Main(string[] args)
        {
            //SIMULACION OFICINA BANCO

            Console.WriteLine("Entran 2 clientes a la vez uno a zona de deposito y otro a retiro ");



            // Crear cuentas bancarias de ejemplo
            Thread.Sleep(1000);
            var cuenta1 = new CuentaBancaria("Fernando Mendoza", 1000);
            var cuenta2 = new CuentaBancaria("David Mendoza", 2000);

            // Crear hilos para operaciones de ingreso y retiro
            var hiloIngreso = new Thread(() => cuenta1.Ingresar(500));
            var hiloRetiro = new Thread(() => cuenta2.Retirar(300));

            var hiloIngreso2 = new Thread(() => cuenta2.Ingresar(1000));
            var hiloRetiro2 = new Thread(() => cuenta1.Retirar(900));


            // Iniciar los hilos
            hiloIngreso.Start();
            hiloRetiro.Start();

            // Esperar a que los hilos terminen
            hiloIngreso.Join();
            hiloRetiro.Join();

            hiloIngreso2.Start();
            hiloRetiro2.Start(); 
            //Esperamos tambien aqui
            hiloIngreso2.Join();
            hiloRetiro2.Join();

            // Mostrar saldos actualizados
            Thread.Sleep(1500);
            Console.WriteLine($"Saldo cuenta 1: {cuenta1.Saldo}");
            Console.WriteLine($"Saldo cuenta 2: {cuenta2.Saldo}");
            Thread.Sleep(1000);
            Console.WriteLine("Los clientes se van. FIN");
        }
    }

    class CuentaBancaria
    {
        public string NombreCuenta { get; }
        public decimal Saldo { get; private set; }

        public CuentaBancaria(string NCuenta, decimal saldoInicial)
        {
            NombreCuenta = NCuenta;
            Saldo = saldoInicial;
            Console.WriteLine($"Cuenta {NombreCuenta} creada con saldo inicial de {Saldo}");
        }

        public void Ingresar(decimal monto)
        {
            // Simulación de operación de ingreso
           
            Thread.Sleep(2500);
            Saldo += monto;
            Console.WriteLine($"Ingreso en cuenta {NombreCuenta}: +{monto}");

        }

        public void Retirar(decimal monto)
        {
            // Simulación de operación de retiro
            
            Thread.Sleep(4000);
            Saldo -= monto;
            Console.WriteLine($"Retiro en cuenta {NombreCuenta}: -{monto}");
        }
    }
}