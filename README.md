CallCenter
==========

  Console Call Center
  
Test Task C# - Call Center

Summary: You need to implement an application that simulates the work of a simple call center.

Brief description: there are 3 types of employees working in call center: operator, manager and senior 

manager. Each employee has the unique ID. When there is incoming call – the system must look for the

first free employee to handle incoming call using next algorithm: the first free operator must handle the 

call, if there are no free operators then the first free manager must do it, if there are no free managers, 

then the first senior manager must handle the call.

Constraints:

 Employee ID is unique

Requirements:

 Console Application or GUI (more preferred)

 Use C# as a programming language

 Use OOP 

 Use multithreading to simulate parallel work of few or more operators

 Code must be commented

 To initialize application data candidate may use any approach (like reading data from file) except 

of hardcoding data in code.

Application should allow users:

1. To see queue of all operators (operators which are busy and free). Something like delimited list 

where user can see status of call center as well as status of specified operator.

2. To start\stop\restart simulation.

3. To see log info for all actions related to call center.

Short business flow description:

1. Before starting simulation user should configure number of operators (according to hierarchy –

see Brief Description). Each operator should be running in separated thread and monitor global 

queue of incoming calls. Once operator (thread) gets incoming call, he should change his status to 

busy and imitate call for some time (min and max bounds must be set by user before starting 

simulation). Once operator ends a call, he should change his status to free and start searching for

a new incoming call.

2. Main thread should generate queue of incoming calls according to user settings.

3. Simulation stops only when one of the following actions happens:

- There are no incoming calls in queue

- User initiates stop of simulation (by pressing stop button).

Use following templates for logging:

After employee handled a call, the following message should appear in the console:

Hello! I’m <employee position> <employee id>.

For example when manager with id 123456 handled a call, the message should be:

Hello! I’m manager 123456.

After employee ended a call, the following message should appear in the console:

<Employee position> <employee id> ended a call.

For example when operator with id 123456 ended a call, the message should be:

Operator 123456 ended a call.

In case there are no free operators the following message should appear in the console:

Sorry! All operators are busy. Try again later.
