# Faire pareil que les recettes mais en changeant les champs

import csv
import json

def get_tags(row, columns):
    tags = []

    tags.append(row[2])
    for i in range (5, 9):
        if (row[i] == "TRUE"):
            tags.append(columns[i])
    return tags

i = 0
with open('Restaurant.csv') as csv_file:
    csv_reader = csv.reader(csv_file, delimiter=',')
    line_count = 0
    columns = []
    for row in csv_reader:
        if line_count == 0:
            print(f'Column names are {", ".join(row)}')
            columns = row
            line_count += 1
        else:
            print(f'\t{row[0]} works in the {row[1]} department, and was born in {row[2]}.')
            line_count += 1
            dictionary = {
                "index": row[0],
                "name": row[1],
                "vegetarianOption": row[3],
                "veganOption": row[4],
                "tags" : get_tags(row, columns)
            }
            with open("Restaurant/"+ str(i) + ".json", "w") as outfile:
                json.dump(dictionary, outfile)
            i += 1
    print(f'Processed {line_count} lines.')
    
    # Data to be written

    