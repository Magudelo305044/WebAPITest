namespace WebAPITest.DAL.Entities
{
    public class SeederDB
    {
        private readonly DataBaseContex _contex;

        public SeederDB(DataBaseContex contex)
        {
            _contex = contex;
        }

        //Creamos un método llamado SeederAsync
        //Este método es una especie de MAIN()
        //Este método tendrá la responsabilidad de prepoblar mis diferentes tablas de la BD

        public async Task SeederAsync()
        {
            //Primero: agregaré un método propio de EF que hace las veces del comando 'update-database¿
            //En otras palabras: un método que me creará la BD inmediatamente ponga en ejecución mi API

            await _contex.Database.EnsureCreatedAsync();

            //A partir de aqui vamos a ir creando métodos que me sirvan para prepoblar mi BD
            await PupulateCountriesAsync();

            await _contex.SaveChangesAsync(); //Esta linea me guarda los cambios en BD

        }

        #region Private Methos

        private async Task PupulateCountriesAsync()
        {
            if (!_contex.Countries.Any()) //el metoro Any() indica si la tabla Countries tiene al menos un registro y el metodo Any Negado (!) indica que no hay asolutamente nada en la tabla
            {
                //Así creo un objeto país con sus respectivos estados
                _contex.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Antioquia",
                        },

                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cundinamarca",
                        }

                    }

                });

                //Así creo otro nuevo País
                _contex.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Argentina",
                    States = new List<State>
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Buenos Aires",
                        },
                    }

                });
            }
        }

        #endregion

    }
}
