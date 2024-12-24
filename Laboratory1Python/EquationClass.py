class Equation:
    def __init__(self):
        self.coefficients = [[0, 0] for _ in range(2)]
        self.constants = [0, 0] 

    def __getitem__(self, index):
        if index < 2:
            return self.coefficients[index] + [self.constants[index]]
        else:
            raise IndexError("Wrong index buddy")

    def __setitem__(self, index, values):
        if index < 2:
            self.coefficients[index] = values[:-1]
            self.constants[index] = values[-1]
        else:
            raise IndexError("Wrong index buddy")

    def input_data(self):
        for i in range(2):
            print(f"Input coefficients for equation {i + 1} (a, b, c):")
            while True:
                try:
                    a = float(input("Enter value for a: "))
                    b = float(input("Enter value for b: "))
                    c = float(input("Enter value for c: "))
                    self[i] = [a, b, c]
                    break
                except ValueError:
                    print("Invalid input. Please enter valid numbers.")

    def output_data(self):
        for i in range(2):
            print(f"{self[i][0]}x + {self[i][1]}y = {self[i][2]}")

    def solve_equation(self):
        determinant = self[0][0] * self[1][1] - self[0][1] * self[1][0]

        if determinant == 0:
            return None 

        determinant_one = self[0][2] * self[1][1] - self[0][1] * self[1][2]
        determinant_two = self[0][0] * self[1][2] - self[0][2] * self[1][0]

        return (determinant_one / determinant, determinant_two / determinant)

    def is_solution(self, x, y):
        epsilon = 1e-9

        print(f"{self[0][0]} * {x} + {self[0][1]} * {y} = {self[0][0] * x + self[0][1] * y}")
        print(f"{self[1][0]} * {x} + {self[1][1]} * {y} = {self[1][0] * x + self[1][1] * y}")

        return abs((self[0][0] * x + self[0][1] * y) - self[0][2]) < epsilon and \
               abs((self[1][0] * x + self[1][1] * y) - self[1][2]) < epsilon
