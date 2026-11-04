pipeline {
    agent any

    stages {

        stage('Checkout') {
            steps {
                echo 'Getting source code from GitHub'
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore CICDProject.sln'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build CICDProject.sln --no-restore'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test CICDProject.sln --no-build'
            }
        }
    }

    post {
        success {
            echo 'CI Pipeline Completed Successfully!'
        }

        failure {
            echo 'CI Pipeline Failed!'
        }
    }
}