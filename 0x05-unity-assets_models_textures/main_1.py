import yaml

def removeUnityTagAlias(filepath):
    """ removes unnecessary Unity tags and adds ID to node"""
    result = str()

    with open(filepath) as srcFile:
        for lineNumber,line in enumerate(srcFile.readlines()): 
            if line.startswith('--- !u!'):          
                result += '\n--- ' + line.split(' ')[2]   # remove the tag, but keep file ID
                result += '\nID: ' + line.split('&')[1]   # add file ID
            else:
                result += line

    return (result)


def loadYAML(filepath):
    """ loads nodes from YAML and appends to list """
    data = removeUnityTagAlias(filepath)
    nodes = list()

    for data in yaml.load_all(data):
        nodes.append(data)
    
    return (nodes)


def checkGameObjectName(nodes):
    objID = None
    for node in nodes:
        if 'GameObject' in node.keys() and 'm_Name' in node['GameObject'].keys():
            if node['GameObject']['m_Name'] == 'Player':
                objID = node['ID']

    if objID == None:
        print("GameObject \'Player\' not found")

    return(objID)


def checkTransform(nodes):
    """ checks Transform XYZ values """

    objID = checkGameObjectName(nodes)

    for node in nodes:
        if 'Transform' in node.keys() and 'm_GameObject' in node['Transform'].keys() and node['Transform']['m_GameObject']['fileID'] == objID:
            transform = node['Transform']
            if transform['m_LocalPosition']['x'] == 0 and transform['m_LocalPosition']['y'] == 1.25 and transform['m_LocalPosition']['z'] == 0:
                print("Position: OK")
            else:
                print("Position: Wrong Value")
            if transform['m_LocalScale']['x'] == 1 and transform['m_LocalScale']['y'] == 1 and transform['m_LocalScale']['z'] == 1:
                print("Scale: OK")
            else:
                print("Scale: Wrong Value")
                

if __name__ == "__main__":
    checkTransform(loadYAML('Assets/Prefabs/Player.prefab'))
    