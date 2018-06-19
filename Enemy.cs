using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LegendofGnome
{
    class Enemy
    {
        public bool isHit = false;
        public int attackCounter;
        public int respawnCounter;
        public int health;
        public int maxHealth = 10;
        public Rectangle enemyRectangle = new Rectangle();
        public Canvas canvas;
        public bool isEnemy;

        public Enemy(Canvas c, Point EnemyPoint)
        {
            canvas = c;
            Canvas.SetTop(enemyRectangle, EnemyPoint.Y);
            Canvas.SetLeft(enemyRectangle, EnemyPoint.X);
            enemyRectangle.Height = 50;
            enemyRectangle.Width = 50;
            enemyRectangle.Fill = Brushes.Red;
            canvas.Children.Add(enemyRectangle);
            health = maxHealth;
            isEnemy = true;
        }

        public Point Move(Point playerPoint, Point enemyPoint)
        {
            if (isEnemy)
            {
                if ((enemyPoint.X <= playerPoint.X + 50 || enemyPoint.X >= playerPoint.X - 50) & (enemyPoint.Y <= playerPoint.Y + 50 & enemyPoint.Y >= playerPoint.Y - 50))
                {
                    isHit = true;
                    if (isHit == true)
                    {
                        //MessageBox.Show("when removed rito banner of command but not irelia");            

                        attackCounter++;
                        //Console.WriteLine(attackCounter);
                        if (attackCounter == 90)
                        {
                            MessageBox.Show("ur mum big gay");
                            attackCounter = 0;
                        }
                    }
                }

                if (enemyPoint.X <= playerPoint.X - 50)
                {
                    enemyPoint.X += 5;
                }
                if (enemyPoint.X >= playerPoint.X + 50)
                {
                    enemyPoint.X -= 5;
                }
                if (enemyPoint.Y >= playerPoint.Y + 50)
                {
                    enemyPoint.Y -= 5;
                }
                if (enemyPoint.Y <= playerPoint.Y - 50)
                {
                    enemyPoint.Y += 5;
                }
                Canvas.SetLeft(enemyRectangle, enemyPoint.X);
                Canvas.SetTop(enemyRectangle, enemyPoint.Y);
            }
            else
            {
                respawnCounter++;
                //Console.WriteLine(attackCounter);
                if (respawnCounter == 300)
                {
                    MessageBox.Show("i never die");
                    respawnCounter = 0;
                    Canvas.SetTop(enemyRectangle, enemyPoint.Y);
                    Canvas.SetLeft(enemyRectangle, enemyPoint.X);
                    canvas.Children.Add(enemyRectangle);
                    isEnemy = true;
                    health = maxHealth;
                }
            }
            return enemyPoint;
        }

        public void attack(int direction)
        {
            //Melee melee = new Melee(canvas);
        }

        public bool hit()
        {
            bool temp = false;
            health--;
            if (health == 0)
            {
                temp = true;
                canvas.Children.Remove(this.enemyRectangle);
                isEnemy = false;
            }
            Console.WriteLine("enemy health: " + health);
            return temp;
        }
    }
}
