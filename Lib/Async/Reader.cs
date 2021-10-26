using System.Threading;
/*
Один процес виробляє повідомлення, призначені для сприйняття та обробку
іншим процесом. Процес, що виробляє повідомлення, називають виробником, а
процес, що сприймає повідомлення – споживачем. Процеси взаємодіють через
деяку узагальнену область пам'яті, яка за змістом є критичним ресурсом. Необхідно
створити декілька виробників (5) та декілька споживачів (5), які намагаються
отримати доступ до змінної. До змінної може одночасно звертатися лише один
процес. Змінна повинна накопичувати повідомлення від виробників. Кожне
повідомлення несе у собі інформацію, який процес його створив. Коли споживач
отримує доступ до змінної, він зменшує кількість повідомлень, але тільки
встановленого виробника, ігноруючи повідомлення інших виробників. Якщо
змінна не містить жодного повідомлення необхідного виробника, споживач
звільнює ресурс та відпочиває. Після виробництва повідомлення процес-виробник
відпочиває. Після вдалого споживання процес-споживач теж відпочиває.
Промоделюйте ситуацію.
*/
using System;

namespace Lib.Async
{
    class Reader
    {
        private MessageBuilder messageBuilder;
        private static readonly Object locker = new Object();

        public Reader(MessageBuilder messageBuilder)
        {
            this.messageBuilder = messageBuilder;
        }

        public void ReadMessage(string name)
        {
            System.Console.WriteLine($"[READER: ReadMessage] Thread ID: {name}");
            messageBuilder.ReadMessage(name);
        }
    }

}
