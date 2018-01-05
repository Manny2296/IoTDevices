import webiopi
GPIO = webiopi.GPIO # Helper for LOW/HIGH values
LIGHT = 17
LIGTH2 = 19
LIGTH3 = 23
LIGTH4 = 21
# Heater plugged on the Expander Pin 7
MIN = 22# Minimum temperature in celsius
MAX = 24 # Maximum temperature in celsius
AUTO = True

# setup function is automatically called at WebIOPi startup
def setup():
    # set the GPIO used by the light to output
    GPIO.setFunction(LIGHT, GPIO.OUT)
    GPIO.setFunction(LIGTH2, GPIO.OUT)

    GPIO.setFunction(LIGTH3, GPIO.OUT)
    GPIO.setFunction(LIGTH4, GPIO.OUT)



    GPIO.digitalWrite(LIGHT, GPIO.LOW)
  
    GPIO.digitalWrite(LIGTH2, GPIO.LOW)
    GPIO.digitalWrite(LIGTH3, GPIO.LOW)
    GPIO.digitalWrite(LIGTH4, GPIO.LOW)
   #  mcp = webiopi.deviceInstance("mcp") # retrieve the device named "mcp" in the configuration 
   #  mcp.setFunction(HEATER, GPIO.OUT)

# loop function is repeatedly called by WebIOPi 
def loop():
    if (AUTO):
        tmp = webiopi.deviceInstance("tmp") # retrieve the device named "tmp" in the configuration
  # retrieve the device named "mcp" in the configuration 

        celsius = tmp.getCelsius() # retrieve current temperature
        print("Temperature: %f" % celsius)

        # Turn ON heater when passing below the minimum temperature
        if (celsius < MIN):
            GPIO.digitalWrite(LIGHT, GPIO.HIGH)

        # Turn OFF heater when reaching maximum temperature
        if (celsius >= MAX):
            GPIO.digitalWrite(LIGHT, GPIO.LOW)

    # gives CPU some time before looping again
    webiopi.sleep(1)
# destroy function is called at WebIOPi shutdown

# a simple macro to return heater mode
@webiopi.macro
def getMode():
    if (AUTO):
        return "auto"
    return "manual"

# simple macro to set and return heater mode
@webiopi.macro
def setMode(mode):
    global AUTO
    if (mode == "auto"):
        AUTO = True
    elif (mode == "manual"):
        AUTO = False
    return getMode()