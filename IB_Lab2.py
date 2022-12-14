import random

k = int(input('Enter k - the number of checking bits.'))
chars = []
while True:
    s = input('Enter ' + str(2 ** k - k - 1) + ' bits to transfer.')
    if len(s) == (2 ** k - k - 1):
        for num in s:
            chars.append(int(num))
        break
for i in range(k):
    chars.insert(2 ** i - 1, 0)

powers = []
for i in range(k):
    powers.append(2 ** i - 1)


def Calculate(arr):
    for i in powers:
        summ = 0
        c = i + 1
        j = i
        while j < 2 ** k - 1:
            if c > 0:
                if j != i:
                    summ += arr[j]
                c -= 1
                j += 1
            else:
                c = i + 1
                j += i + 1
        arr[i] = int(summ % 2 == 1)
    return arr


chars = Calculate(chars)

print("Initial: \n" + "".join(map(str, chars)))

broken = random.randint(0, 2 ** k - 2)
chars[broken] = int(chars[broken] == 0)

print("Broken: \n" + "".join(map(str, chars)))
copy_chars = list(chars)
copy_chars = Calculate(copy_chars)

print("Recalculated: \n" + "".join(map(str, copy_chars)))
wrong = []
for i in powers:
    if copy_chars[i] != chars[i]:
        wrong.append(i)
index = sum(wrong) + len(wrong) - 1
chars[index] = int(chars[index] == 0)
print('Fixed:\n' + "".join(map(str, chars)))
print('Error was in position ' + str(index + 1))
