import sys

mem = {1: [[1, 1], [1, 0]]}


def exp(m, n):
    if n in mem:
        return mem[n]
    mem[n] = mul(exp(m, n / 2), exp(m, n / 2))
    return mem[n]


def mul(m, n):
    m11 = m[0][0] * n[0][0] + m[0][1] * n[1][0]
    m21 = m[1][0] * n[0][0] + m[1][1] * n[1][0]
    m12 = m[0][0] * n[0][1] + m[0][1] * n[1][1]
    m22 = m[1][0] * n[0][1] + m[1][1] * n[1][1]
    return [[m11, m12], [m21, m22]]


def fib(n):
    sign = 1
    a = [[1, 1], [1, 0]]
    m = [[1, 0], [0, 1]]
    if n < 0:
        sign = -1 if n % 2 == 0 else sign
        n *= -1
    i = 0
    while n >> i >= 1:
        p = n & (1 << i)
        if p:
            m = mul(m, exp(a, p))
        i += 1

    return m[0][1] * sign


def fib2(n):
    a, b = 0, 1
    for i in range(abs(n)):
        a, b = b, a + b
    if n < 0 and n % 2 == 0: a *= -1
    return a

if __name__ == "__main__":
    # print(fib(int(sys.argv[1])))
    print(fib2(int(sys.argv[1])))

