import matplotlib as mpl
import matplotlib.pyplot as plt
import numpy as np

with open("heart_rate.dat","r") as f:
    heart_list = f.readlines()
# heart_list = [x.strip() for x in heart_list]
heart_list = [float(x.strip()) for x in heart_list] # heart rates
# heart_list = [x/np.mean(heart_list) for x in heart_list] # heart rates normalized by mean
# heart_list = [x-np.min(heart_list) for x in heart_list] # heart rates normalized by min

# print(heart_list)
# new_heart_list = []
# cur_rate = heart_list[0]
# for rate in heart_list:
#     if cur_rate != rate:
#         cur_rate = rate
#         new_heart_list.append(cur_rate)

# print(new_heart_list)

x = np.arange(len(heart_list))

fig, ax = plt.subplots()
ax.plot(x, heart_list)

ax.set(xlabel='time', ylabel='heart rate',
       title='heart rate during the game')

ax.set(ylim=(0, 200))

# fig.savefig("test.png")
plt.show()

input("Press Enter to exit...")
