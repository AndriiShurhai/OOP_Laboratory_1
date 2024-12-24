import unittest
import math
from TCircleClass import TCircle

class TestTCircle(unittest.TestCase):

    def test_constructor_default_should_set_radius_to_zero(self):
        circle = TCircle()
        self.assertEqual(circle.radius, 0)

    def test_constructor_with_radius_should_set_radius_correctly(self):
        radius = 5
        circle = TCircle(radius)
        self.assertEqual(circle.radius, radius)

    def test_constructor_with_negative_radius_should_raise_value_error(self):
        radius = -5
        with self.assertRaises(ValueError):
            TCircle(radius)

    def test_constructor_copy_should_copy_radius_correctly(self):
        original_circle = TCircle(5)
        new_circle = TCircle(original_circle)
        self.assertEqual(original_circle.radius, new_circle.radius)

    def test_radius_set_valid_value_should_update_radius(self):
        circle = TCircle()
        new_radius = 10
        circle.radius = new_radius
        self.assertEqual(circle.radius, new_radius)

    def test_radius_set_negative_value_should_raise_value_error(self):
        circle = TCircle()
        with self.assertRaises(ValueError):
            circle.radius = -10

    def test_calculate_area_should_return_correct_area(self):
        radius = 5
        circle = TCircle(radius)
        expected_area = math.pi * radius * radius
        self.assertAlmostEqual(circle.calculate_area(), expected_area, places=5)

    def test_calculate_sector_area_should_return_correct_sector_area(self):
        radius = 5
        angle = 90
        circle = TCircle(radius)
        expected_sector_area = (angle / 360.0) * math.pi * radius * radius
        self.assertAlmostEqual(circle.calculate_sector_area(angle), expected_sector_area, places=5)

    def test_calculate_circle_length_should_return_correct_length(self):
        radius = 5
        circle = TCircle(radius)
        expected_length = 2 * math.pi * radius
        self.assertAlmostEqual(circle.calculate_circle_length(), expected_length, places=5)

    def test_compare_to_should_compare_circles_correctly(self):
        circle1 = TCircle(10)
        circle2 = TCircle(10)
        self.assertEqual(circle1.compare_to(circle2), 0)

    def test_operator_add_should_return_circle_with_combined_radius(self):
        circle1 = TCircle(5)
        circle2 = TCircle(3)
        expected_radius = 8
        result = circle1 + circle2
        self.assertEqual(result.radius, expected_radius)

    def test_operator_subtract_should_return_circle_with_difference_of_radius(self):
        circle1 = TCircle(5)
        circle2 = TCircle(3)
        expected_radius = 2
        result = circle1 - circle2
        self.assertEqual(result.radius, expected_radius)

    def test_operator_multiply_should_return_circle_with_multiplied_radius(self):
        circle = TCircle(5)
        multiplier = 2
        expected_radius = 10
        result = circle * multiplier
        self.assertEqual(result.radius, expected_radius)

    def test_operator_multiply_by_double_should_return_circle_with_multiplied_radius(self):
        circle = TCircle(5)
        multiplier = 3
        expected_radius = 15
        result = multiplier * circle
        self.assertEqual(result.radius, expected_radius)
