import math
from TCircleClass import TCircle

class TSphere(TCircle):
    def __init__(self, radius=None):
        super().__init__(radius)
        self.__radius = radius

    def calculate_volume(self):
        return (4 / 3.0) * math.pi * math.pow(self.__radius, 3)

    def calculate_area(self):
        return 4 * math.pi * math.pow(self.__radius, 2)

    def __add__(self, other_sphere):
        return TSphere(self.__radius + other_sphere.radius)

    def __sub__(self, other_sphere):
        return TSphere(abs(self.__radius - other_sphere.radius))

    def __mul__(self, number):
        if isinstance(number, (int, float)):
            return TSphere(self.__radius * number)
        else:
            raise TypeError("Multiplication with non-numeric values is not supported.")

    def __rmul__(self, number):
        return self.__mul__(number)

    def __str__(self):
        return f"Sphere with radius {self.__radius}"