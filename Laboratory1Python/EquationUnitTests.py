import unittest
from EquationClass import Equation
from math import isclose

class TestEquation(unittest.TestCase):

    def test_indexer_get_and_set_should_work_correctly(self):
        equation = Equation()

        equation[0] = [2, 3, 4]

        self.assertEqual(equation[0][0], 2)
        self.assertEqual(equation[0][1], 3)
        self.assertEqual(equation[0][2], 4)

    def test_indexer_should_throw_index_error_for_invalid_index(self):
        equation = Equation()

        with self.assertRaises(IndexError):
            equation[0][3] = 5
        with self.assertRaises(IndexError):
            equation[2][0] = 5

    def test_solve_equation_should_return_correct_solution(self):
        equation = Equation()

        # 2x + y = 5
        equation[0] = [2, 1, 5]
        # x - y = 1
        equation[1] = [1, -1, 1]

        solution = equation.solve_equation()

        self.assertIsNotNone(solution)
        x, y = solution
        self.assertTrue(isclose(x, 2, abs_tol=1e-9))
        self.assertTrue(isclose(y, 1, abs_tol=1e-9))

    def test_solve_equation_should_return_none_for_no_solution(self):
        equation = Equation()

        equation[0] = [1, 2, 3]
        equation[1] = [2, 4, 6]

        solution = equation.solve_equation()

        self.assertIsNone(solution)

    def test_is_solution_should_return_true_for_correct_solution(self):
        equation = Equation()

        # 2x + y = 5
        equation[0] = [2, 1, 5]
        # x - y = 1
        equation[1] = [1, -1, 1]

        is_valid = equation.is_solution(2, 1)
        self.assertTrue(is_valid)

    def test_is_solution_should_return_false_for_incorrect_solution(self):
        equation = Equation()

        # 2x + y = 5
        equation[0] = [2, 1, 5]
        # x - y = 1
        equation[1] = [1, -1, 1]

        is_valid = equation.is_solution(0, 0)
        self.assertFalse(is_valid)