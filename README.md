## VU Simple Blockchain implementation
Simple blockchain simulations implementation ofr Vilnius University "Blockchain techbologies" couse.

# Description
The purpose of the project is to create a simple blockchain simulation which involves:
- Generating users
- Generating transactions
- Generating block candidates for mining
- Mining the block
- Transaction validation
- Adding the block to the blockchain
- Outputing formated data in txt files
- Achieving mining with parallel programing.

# Data generation
At startup, program generates 100 users and 1000 transactions that are spread between users.

# Block mining
five candidate blocks are generated. Then, candidate blocks are mined in parallel and single block is returned from the parallel process that finished mining first. Mentioned process is repeated until transactions pool is empty.

# Transaction validation 
When a mined block is returned, all the transactions get validated. Firstly we compare if the transactions hash is as same as the hash of senders hash + receivers hash + amount. If so then the code validetes if senders balance is greater than the amount of transaction. After validation the balances of sender and receiver get updated. 

# Data output
After the simulation is finished, in "@\Blockchain\SimpleBlockChain\SimpleBlockChain\SimpleBlockChain\bin\Debug\Results" 3 files are created:
- Users
- Transactions
- Blocks
