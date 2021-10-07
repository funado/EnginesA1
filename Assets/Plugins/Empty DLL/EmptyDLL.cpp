#define EXPORT_API __declspec(dllexport)

#include <iostream>
using namespace std;

//Link following functions C-Style (required for plugins)
extern "C"
{
	int EXPORT_API ReturnRed(int a)
	{
		
	}
	int EXPORT_API ReturnBlue(int b)
	{
		
	}
	int EXPORT_API ReturnGreen(int c)
	{
		
	}

} //End of export C block
