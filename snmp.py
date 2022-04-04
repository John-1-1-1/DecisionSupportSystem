from pysnmp.entity.rfc3413.oneliner import cmdgen
from pysnmp.proto.rfc1902 import Integer, IpAddress, OctetString
ip='10.90.90.90'
community='public'
value1=(1,3,6,1,4,1,171,12,11,1,8,1,2,1)# temperature
value = (1,3,6,1,4,1,171,12,1,1,6,1,0)
generator = cmdgen.CommandGenerator()
comm_data = cmdgen.CommunityData('server', community, 1) # 1 means version SNMP v2c
transport = cmdgen.UdpTransportTarget((ip, 161))
real_fun = getattr(generator, 'getCmd')

def get_value(values):
    ret = []
    for ind in values:
        value = list(map(int, ind.split(".")))

        res = (errorIndication, errorStatus, errorIndex, varBinds) \
            = real_fun(comm_data, transport, value)

        if not errorIndication is None or errorStatus is True:
            print("Error: %s %s %s %s" % res)
            ret.append("Error")
        else:
            print("%s" % varBinds)
            ret.append(varBinds[0][-1]._value)
    return ret

