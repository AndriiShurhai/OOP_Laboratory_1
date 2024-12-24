import math

class TCircle:
    def __init__(self, radius=None):
        if isinstance(radius, TCircle):
            self.__radius = radius.radius
        elif radius is None:
            self.__radius = 0
        else:
            self.validate_input(radius)
            self.__radius = radius

    
    @property
    def radius(self):
        return self.__radius
    
    @radius.setter
    def radius(self, value):
        self.validate_input(value)
        self.__radius = value
    
    def __str__(self):
        return f"Circle with radius {self.__radius}"
    
    def input(self):
        while True:
            try:
                radius_input = float(input("Please enter radius: "))
                if radius_input < 0:
                    raise ValueError("Radius must be greater than or equal to zero.")
                self.__radius = radius_input
                break
            except ValueError:
                print("Wrong input buddy, value must be a number and greater than or equal to zero. Try again.")

    def calculate_area(self):
        return math.pi * self.__radius * self.__radius

    def calculate_sector_area(self, angle):
        return (angle / 360.0) * self.calculate_area()

    def calculate_circle_length(self):
        return 2 * math.pi * self.__radius

    def compare_to(self, other_circle):
        if self.__radius > other_circle.radius:
            return 1
        elif self.__radius < other_circle.radius:
            return -1
        else:
            return 0
        
    def __add__(self, other_circle):
        return TCircle(self.__radius + other_circle.radius)

    def __sub__(self, other_circle):
        return TCircle(abs(self.__radius - other_circle.radius))

    def __mul__(self, value):
        if isinstance(value, (int, float)):
            return TCircle(self.__radius * value)
        else:
            raise TypeError("Multiplication with non-numeric values is not supported.")
    
    def __rmul__(self, value):
        return self.__mul__(value)
    
    @staticmethod
    def validate_input(value):
        if value is None or value < 0:
            raise ValueError("Radius must be greater than or equal to zero.")