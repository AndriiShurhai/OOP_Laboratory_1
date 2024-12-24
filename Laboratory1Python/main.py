from TCircleClass import TCircle
from TSphereClass import TSphere
from EquationClass import Equation

def execute_first():
    equation = Equation()
    equation.input_data()
    equation.output_data()

    solution = equation.solve_equation()
    if solution != None:
        print(f"Solution: x = {solution[0]}; y = {solution[1]}")
        print(equation.is_solution(solution[0], solution[1]))
    else:
        print("Equation has no solution")

def execute_second():
    circle = TCircle(6)
    print(circle.__radius)

    print("=== TCircle Examples ===")
    
    circle1 = TCircle(5)
    circle2 = TCircle(3)

    print(circle1.radius)
    print(circle2.radius)

    circle1.input()
    circle2.input()
    print()
    
    print(f"Circle 1: {circle1}")
    print(f"Circle 2: {circle2}")
    
    print(f"Circle 1 Area: {circle1.calculate_area()}")
    print(f"Circle 1 Length: {circle1.calculate_circle_length()}")
    
    circle_sum = circle1 + circle2
    print(f"Sum of Circle 1 and Circle 2 (radius): {circle_sum}")
    
    circle_diff = circle1 - circle2
    print(f"Difference of Circle 1 and Circle 2 (radius): {circle_diff}")
    
    circle_scaled = circle1 * 2
    print(f"Circle 1 scaled by 2 (radius): {circle_scaled}")

    circle_scaled = 2 * circle1
    print(f"2 scaled by Circle 1 (radius): {circle_scaled}")

    comparison_result = circle1.compare_to(circle2)
    comparison_message = ["smaller than", "equal to", "greater than"][comparison_result + 1]
    print(f"Circle 1 is {comparison_message} Circle 2.")
    print()

    print("\n=== TSphere Examples ===")
    
    sphere1 = TSphere(10)
    sphere2 = TSphere(15)

    print(sphere1.radius)
    print(sphere2.radius)

    sphere1.input()
    sphere2.input()
    
    print(f"Sphere 1: {sphere1}")
    print(f"Sphere 2: {sphere2}")
    
    print(f"Sphere 1 Volume: {sphere1.calculate_volume()}")
    print(f"Sphere 1 Area: {sphere1.calculate_area()}")
    
    sphere_sum = sphere1 + sphere2
    print(f"Sum of Sphere 1 and Sphere 2 (radius): {sphere_sum}")
    
    sphere_diff = sphere1 - sphere2
    print(f"Difference of Sphere 1 and Sphere 2 (radius): {sphere_diff}")
    
    sphere_scaled = sphere1 * 2
    print(f"Sphere 1 scaled by 2 (radius): {sphere_scaled}")

    comparison_result = sphere1.compare_to(sphere2)
    comparison_message = ["smaller than", "equal to", "greater than"][comparison_result + 1]
    print(f"Sphere 1 is {comparison_message} Sphere 2.")
    print()


if __name__ == "__main__":
    choice = input("Which program to execute?\n1 - Equation\n2 - TCircle\n")

    while choice != '0':

        if choice == '1':
            execute_first()
        elif choice == '2':
            execute_second()
        elif choice == '0':
            print('Leaving program.')
        else:
            print("Try again")
        
        choice = input("Which program to execute?\n1 - Equation\n2 - TCircle\n")
    
