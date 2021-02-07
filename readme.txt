THE TASK:

Бихме желали, да се запознаем със стила Ви на писане. Можете да намерите прикачено условието на една задачка, която не би трябвало да Ви затрудни или отнеме много време. 
(Малка подсказка – третирайте задачката като реален проект 😉 )


Create a console application that would calculate net salary given the gross value as input. The taxation rules in the country of Imaginaria as of date are as follows:
1.)	There is no taxation for any amount lower or equal to 1000 Imagiaria Dolars (IDR).
2.)	Income tax of 10% is incurred to the excess (amount above 1000).
3.)	Social contributions of 15% are expected to be made as well. As for the previous case, the taxable income is whatever is above 1000 IDR but social contributions never apply to amounts higher than 3000. 

Example 1 : George has a salary of 980 IDR. He would pay no taxes since this is below the taxation threshold and his net income is also 980.
Example 2 : Irina has a salary of 3400 IDR. She owns income tax : 10% out of 2400 => 240. Her Social contributions are 15% out of 2000 => 300. In total her tax is 540 and she gets to bring home 2860 IDR

*After completing the task, please leave some comments explaining why you have chosen your approach.


###################################################################################################

IMPLEMENTATION NOTES:

Strategy pattern has been implemented for this task. There are other ways to design the solution, but in my opinion this is the simplest one 
that covers the requirements and can be extended easily.
To add a new tax, just create new class which inherits from ITaxRule and pass it to the calculator's constructor. The calculator will not 
change when new taxes are added.
Using reflection the tax rules could be loaded dynamically from assembly or/and from a configuration file.
