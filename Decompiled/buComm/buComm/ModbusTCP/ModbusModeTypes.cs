namespace buComm.ModbusTCP;

public enum ModbusModeTypes
{
	ReadCoils = 1,
	ReadDiscreteInputs,
	ReadHoldingRegister,
	ReadInputRegister,
	WriteSingleCoil,
	WriteMultipleCoils,
	WriteSingleRegister,
	WriteMultipleRegister
}
