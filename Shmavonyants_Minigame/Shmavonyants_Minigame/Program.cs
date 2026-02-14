internal class Program
{
    private static void Main(string[] args)
    {
        static void ColorThis(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        ColorThis("Я проснулся в незнакомой комнате.\nВ голове туман, даже собственное имя вспомнить тяжело.\nМеня зовут...", ConsoleColor.Yellow);
        string name;
        
        do
        {
            name = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(name));
        Console.WriteLine("");

        ColorThis("Точно, меня зовут " + name + "!\nЭто понятно, но неплохо бы выбраться отсюда...", ConsoleColor.Yellow);
        bool DoorOpen = false;
        bool BedArtifact = false;
        bool BoxOpen = false;
        int VentAttempts = 0;
        bool DrawerArtifact = false;
        bool StatueActive = false;
        while (!DoorOpen)
        {
            ColorThis("\na. Открыть дверь\nb. Заглянуть под кровать\nc. Открыть ящик в углу комнаты\nd. Открыть вентиляцию\ne. Взглянуть на тумбочку\nf. Взглянуть на статую рядом с дверью", ConsoleColor.Cyan);
            char action = char.ToLower(Console.ReadKey().KeyChar);

            Console.WriteLine("");
            Console.WriteLine("");

            if (action == 'a')
            {
                if (!BoxOpen)
                {
                    ColorThis("Дверь заперта. Тут бы пригодилась какая-нибудь отмычка...", ConsoleColor.Red);
                }
                else
                {
                    ColorThis("Я открываю дверь отмычкой. Свобода!", ConsoleColor.Green);
                    DoorOpen = true;
                }
            }
            else if (action == 'b')
            {
                if (!BedArtifact)
                {
                    ColorThis("Я смотрю под кровать. Под ней лежит кольцо с аметистом! Сохраню его до поры до времени.", ConsoleColor.Green);
                    BedArtifact = true;
                }
                else
                {
                    ColorThis("Там я уже смотрел.", ConsoleColor.Red);
                }
            }
            else if (action == 'c')
            {
                if (!BoxOpen)
                {
                    if (!StatueActive)
                    {
                        ColorThis("Ящик заперт. Похоже, мне нужен ключ.", ConsoleColor.Red);
                    }
                    else
                    {
                        ColorThis("Я открываю ящик ключом. В нём лежит отмычка! Возможно, я могу её для чего-то использовать?", ConsoleColor.Green);
                        BoxOpen = true;
                    }
                }
                else
                {
                    ColorThis("Ящик пуст.", ConsoleColor.Red);
                }
            }
            else if (action == 'd')
            {
                if (VentAttempts == 0)
                {
                    ColorThis("Я пробую открыть вентиляцию. Она слегка поддалась!", ConsoleColor.Green);
                    VentAttempts = 1;
                }
                else if (VentAttempts == 1)
                {
                    ColorThis("Я пробую ещё раз. Ещё немного!", ConsoleColor.Green);
                    VentAttempts = 2;
                }
                else if (VentAttempts == 2)
                {
                    ColorThis("Мне удалось снять вентиляционную решётку! Внутри я нашёл кольцо с рубином! Сохраню его, вдруг пригодится.", ConsoleColor.Green);
                    VentAttempts = 3;
                }
                else
                {
                    ColorThis("Я уже достал оттуда кольцо", ConsoleColor.Red);
                }
            }
            else if (action == 'e')
            {
                if (!DrawerArtifact)
                {
                    ColorThis("Я смотрю на тумбочку. На ней лежит кольцо с изумрудом! Сохраню его пока, на всякий случай.", ConsoleColor.Green);
                    DrawerArtifact = true;
                }
                else
                {
                    ColorThis("Сейчас на тумбочке уже ничего нет.", ConsoleColor.Red);
                }
            }
            else if (action == 'f')
            {
                if (!StatueActive)
                {
                    if (BedArtifact && VentAttempts == 3 && DrawerArtifact)
                    {
                        ColorThis("Я надеваю кольца на руку статуe. Она немного сдвинулась с пъедестала в сторону. Под ней открылась полость с ключом! Возьму его, наверняка, он для чего-то нужен!", ConsoleColor.Green);
                        StatueActive = true;
                    }
                    else
                    {
                        ColorThis("Статуя вытягивает 3 пальца. Возможно, это что-то значит?", ConsoleColor.Yellow);
                    }
                }
                else
                {
                    ColorThis("Статую уже активирована.", ConsoleColor.Red);
                }
            }
        }
    }
}