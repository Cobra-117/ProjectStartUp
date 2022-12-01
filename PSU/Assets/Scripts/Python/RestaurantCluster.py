import csv
import json
from array import * 

i = 0
with open('Restaurant.csv') as csv_file:
    csv_reader = csv.reader(csv_file, delimiter=',')
    line_count = 0
    columns = []
    w, h = 25, 10
    tags = [[str(-1) for x in range(w)] for y in range(h)]  #contain name, then dish index
    i = 0
    for row in csv_reader:
        if line_count == 0:
            print(f'Column names are {", ".join(row)}')
            columns = row
            line_count += 1
        else:
            print(f'\t{row[0]} works in the {row[1]} department, and was born in {row[2]}.')
            line_count += 1
            for x in range(5,9):
                if (row[x] == "TRUE"):
                    tags[x - 5].insert(0, str(i))
            i += 1
    print(f'Processed {line_count} lines.')
    #print(columns)
    print(tags)
    for j in range(len(tags)):
        with open("restCluster/"+ str(j) + ".json", "w") as outfile:
                dictionary = {
                "index": j,
                "name": columns[j + 5],
                "restaurant" : tags[j]
            }
                json.dump(dictionary, outfile)
    
    # Data to be written

    