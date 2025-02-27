namespace Wine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Cargo> cargoList = GenerateCargoData(50);
            DisplayCargoData(cargoList);
        }
        public static List<Cargo> GenerateCargoData(int count)
        {
            Random random = new Random();
            List<Cargo> cargoList = new List<Cargo>();

            for (int i = 1; i <= count; i++)
            {
                double weight = Math.Round(random.Next(1, 10) + random.NextDouble(), 2);

                cargoList.Add(new Cargo
                {

                    Name = $"Вино {i}",
                    MinQuantity = random.Next(1, 10),
                    MaxQuantity = random.Next(20, 100),
                    WeightPerUnit = weight
                });
            }

            return cargoList;
        }
        private void DisplayCargoData(List<Cargo> cargoList)
        {
            dataGridView1.DataSource = cargoList;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private List<Cargo> OptimizeCargo(List<Cargo> cargoList, double maxWeight)
        {
            List<Cargo> optimizedList = new List<Cargo>();
            double totalWeight = 0;

            // Сортируем грузы по убыванию веса на единицу
            var sortedCargo = cargoList.OrderByDescending(c => c.WeightPerUnit).ToList();

            foreach (var cargo in sortedCargo)
            {
                int quantity = cargo.MaxQuantity;
                double cargoWeight = quantity * cargo.WeightPerUnit;

                if (totalWeight + cargoWeight <= maxWeight)
                {
                    optimizedList.Add(new Cargo
                    {
                        Name = cargo.Name,
                        MinQuantity = cargo.MinQuantity,
                        MaxQuantity = quantity,
                        WeightPerUnit = cargo.WeightPerUnit
                    });
                    totalWeight += cargoWeight;
                }
                else
                {
                    int remainingQuantity = (int)((maxWeight - totalWeight) / cargo.WeightPerUnit);
                    if (remainingQuantity >= cargo.MinQuantity)
                    {
                        optimizedList.Add(new Cargo
                        {
                            Name = cargo.Name,
                            MinQuantity = cargo.MinQuantity,
                            MaxQuantity = remainingQuantity,
                            WeightPerUnit = cargo.WeightPerUnit
                        });
                        totalWeight += remainingQuantity * cargo.WeightPerUnit;
                    }
                }
            }

            return optimizedList;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtMaxWeight.Text, out double maxWeight))
            {
                MessageBox.Show("Введите корректное значение для максимального веса.");
                return;
            }

            List<Cargo> cargoList = (List<Cargo>)dataGridView1.DataSource;
            List<Cargo> optimizedList = OptimizeCargo(cargoList, maxWeight);

            // Вывод результата
            double totalWeight = optimizedList.Sum(c => c.MaxQuantity * c.WeightPerUnit);
            lblResult.Text = $"Оптимизированный вес: {totalWeight}";

            // Отображение оптимизированных данных
            DisplayCargoData(optimizedList);
        }
        private void btnEditData_Click(object sender, EventArgs e)
        {
            List<Cargo> cargoList = (List<Cargo>)dataGridView1.DataSource;
            cargoList[0].MaxQuantity = 50; // Пример изменения данных
            DisplayCargoData(cargoList);
        }
    }
}
