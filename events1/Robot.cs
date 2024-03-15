using System;
namespace events1
{
	public class Robot
	{
		public int x = 0;
		public int y = 0;
		public int speed = 1;
		public Robot()
		{
		}

		public string Move()
		{
			Random rnd = new Random();
			int val = rnd.Next(0, 4);
			switch (val)
			{
				case 0:
					this.y += this.speed;
					return "Вперед";
				case 1:
					this.y -= this.speed;
                    onBack(this);
                    return "Назад";
				case 2:
					this.x -= this.speed;
					return "Влево";
				case 3:
					this.x += this.speed;
					return "Вправо";
				default:
					return "";
			}
		}
		public delegate void FileSaver(Robot robot);

		public event FileSaver onBack;

	}
}

