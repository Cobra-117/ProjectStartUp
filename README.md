 lines (22 sloc) 1.33 KB
# How to use Git
- Configure ssh key :https://docs.github.com/en/authentication/managing-commit-signature-verification
- Install a git manager like Git GUI
- Clone this repository
- Switch to dev branch ("git checkout dev" or by using the UI)
- Pull to get everything make by the other (git pull)
- Follow next part

# Working with branch
Branch help up keep organised and not fuck up everything. The master branch should only contain testing in working things. Each feature or part of
the app should be made in a separate branch. Each branch should modifiy it's own scenes and files to prevent conflicts.
When merging branch, do it on dev the branch and when we are together. Once everything is tested, the dev branch can be merged with the
master branch.

### How to do it?
- Switch the branch you will work on using "git checkout {name_of_the_branch}" or the UI
- If you need to create a new branch, you can do it from dev branch with "git branch {name_of_the_branch}" (or using the UI)
- Pull (git pull) to be sure to be up to date with what the others made

### How to add your modifications?
- Add everything modified ("git add *" or via the UI) 
- The .gitignore file will prevent Unity files we don't want to to be added
- Commit with an explicit message about what you changed ("git commit -m {message}" or using the UI)
- Pull (git pull)
- Push (git push)
