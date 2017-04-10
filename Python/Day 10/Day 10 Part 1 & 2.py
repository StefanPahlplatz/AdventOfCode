import re
from numpy import prod
from BotClass import Bot


def find_bot(number):
    """ returns the index of the bot that has the number. """
    for i in range(0, len(bots)):
        bot = bots[i]
        if bot.number == number:
            return i
    return None


def assign_values(lines):
    """ Initializes bots with their initial value. """
    for line in lines:
        if "value" in line:
            info = re.findall("\d+", line)  # 0 = initial bot value, 1 = bot number
            bot_index = find_bot(int(info[1]))
            if bot_index is not None:
                bots[bot_index].receive_value(int(info[0]))
            else:
                bot = Bot(int(info[1]))
                bot.receive_value(int(info[0]))
                bots.append(bot)


def assign_rules(lines):
    """ Assigns the rules to each bot. """
    only_bots = re.compile("(bot.+){3}")
    for line in lines:
        if "bot" in line[:3]:
            if only_bots.match(line):
                # The bot passes it's values only to other bots.
                values = re.findall("\d+", line)
                number = int(values[0])
                low = int(values[1])
                high = int(values[2])

                bot_index = find_bot(number)
                if bot_index is not None:
                    # The bot is already in the list.
                    bot = bots[bot_index]
                    bot.give_low_to = low
                    bot.give_high_to = high
                else:
                    # The bot is not yet in the list.
                    bot = Bot(number, low, high)
                    bots.append(bot)
            else:
                # The bot passes it's values to other bots, but also to outputs
                values = re.findall("bot (\d+)|output (\d+)", line)
                number = int(values[0][0])
                low = int(values[1][0] if values[1][0] != "" else values[1][1])
                high = int(values[2][0] if values[2][0] != "" else values[2][1])
                low_to_bot = (values[1][1] == "")
                high_to_bot = (values[2][1] == "")
                bot_index = find_bot(number)
                if bot_index is not None:
                    # The bot is already in the list.
                    bot = bots[bot_index]
                    bot.set_low(low, low_to_bot)
                    bot.set_high(high, high_to_bot)
                else:
                    # The bot is not yet in the list.
                    bot = Bot(number)
                    bot.set_low(low, low_to_bot)
                    bot.set_high(high, high_to_bot)
                    bots.append(bot)


def pass_values():
    for k in range(0, 25):
        for bot in bots:
            if bot.has_two_values():
                values = bot.get_values()

                # Pass the low value.
                if bot.get_low_to_bot():
                    bot_index = find_bot(bot.give_low_to)
                    bot_pass = bots[bot_index]
                    bot_pass.receive_value(min(values))
                else:
                    if bot.give_low_to in [0, 1, 2]:
                        part2.append(min(values))
                bot.set_low = None

                # Pass the high value.
                if bot.get_high_to_bot():
                    bot_index = find_bot(bot.give_high_to)
                    bot_pass = bots[bot_index]
                    bot_pass.receive_value(max(values))
                else:
                    if bot.give_high_to in [0, 1, 2]:
                        part2.append(max(values))
                bot.set_high = None

bots = []
part2 = []

# Initialize bots
with open("day10.txt") as file:
    assign_values(file)
with open("day10.txt") as file:
    assign_rules(file)

pass_values()

print("Answer part 2:", prod(part2))
