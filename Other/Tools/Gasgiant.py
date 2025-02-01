import csv

csvFilePath = "C:\\Users\\Administrator\\Desktop\\1\\saturn.csv"

class LinearInterpolation:
    data: list

    def __init__(self, data: list):
        self.data = sorted(data, key = lambda item: item[0])
        print(self.data)

    def evaluate(self, x: float) -> float:
        if x <= self.data[0][0]:
            return self.data[0][1]
        if x >= self.data[len(self.data) - 1][0]:
            return self.data[len(self.data) - 1][1]

        rightIndex = 0
        for i in range(0, len(self.data)):
            if self.data[i][0] >= x:
                rightIndex = i
                break
        leftIndex = rightIndex - 1
        left = self.data[leftIndex]
        right = self.data[rightIndex]
        k = float(x - left[0]) / float(right[0] - left[0])
        return left[1] * (1.0 - k) + right[1] * k

def main():
    fp = open(csvFilePath)
    reader = csv.reader(fp, delimiter=',')
    data = [[float(item) for item in row] for row in reader]
    fp.close()

    linear = LinearInterpolation(data)
    while True:
        x = float(input("Input X: "))
        print(linear.evaluate(x))

main()