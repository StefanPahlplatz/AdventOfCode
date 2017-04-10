class Bot(object):
    number = None

    def __init__(self, number, give_low_to=None, give_high_to=None):
        self.number = number
        self.give = []
        self.give_low_to = give_low_to
        self.give_high_to = give_high_to
        self.low_to_bot = True
        self.high_to_bot = True

    def receive_value(self, value):
        self.give.append(value)
        self.has_search_value()

    def has_search_value(self):
        if 17 in self.give and 61 in self.give:
            print("Answer part 1:", self.number)

    def set_low(self, nr, low_to_bot=True):
        self.give_low_to = nr
        self.low_to_bot = low_to_bot

    def set_high(self, nr, high_to_bot=True):
        self.give_high_to = nr
        self.high_to_bot = high_to_bot

    def get_number(self):
        return self.number

    def has_two_values(self):
        try:
            return self.give[0] is not None and self.give[1] is not None
        except:
            return False

    def get_values(self):
        copy = self.give
        self.give = [None]
        return copy

    def get_low_to_bot(self):
        return self.low_to_bot

    def get_high_to_bot(self):
        return self.high_to_bot

    def __str__(self):
        return "Bot: " + str(self.number) + "  \tlow to " + str(self.give_low_to) + "\t\thigh to: " \
               + str(self.give_high_to) + "   \t\tcurrent values: " + str(self.give) \
               + " - " + str(self.low_to_bot) + "," + str(self.high_to_bot)
